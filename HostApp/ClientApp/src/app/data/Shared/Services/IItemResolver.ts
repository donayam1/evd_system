import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Resource } from '../Models/Network/Resource';
import { SearchIndex } from '../../Search/Models/search.model';
import { RemoteItemResolver } from './RemoteItemResolver';


export interface IItemResolver {
    type: number;
    GetById(id: string, type: number): Observable<Resource<any>>;
}


@Injectable({
    "providedIn": 'root'
})
export class ItemResolverFactory {

    resolvers = new Map;
    constructor(private remoteResolver: RemoteItemResolver
    ) { // @Inject(ITEMRESOLVERS) private itemResolvers: IItemResolver[]) {
    }

    GetResolver(type: number): IItemResolver {
        const itemResolvers = <IItemResolver>this.resolvers.get(type);
        if (itemResolvers == null) {
            return this.remoteResolver;
        }
        return itemResolvers;
    }

    Register(resolver: IItemResolver) {
        this.resolvers.set(resolver.type, resolver);
    }

    Resolve(itemId: string, itemType: number): Observable<Resource<SearchIndex>> {
        const myResolver = this.GetResolver(itemType);
        if (myResolver == null) {
            return this.remoteResolver.GetById(itemId, itemType);
        }
        return myResolver.GetById(itemId, itemType);
    }

}
