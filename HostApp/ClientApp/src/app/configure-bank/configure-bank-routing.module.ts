import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { CreateBankComponent } from './create-bank/create-bank.component';
import { ListConfigureBankComponent } from './list-configure-bank/list-configure-bank.component';

const routes: Routes = [
  {path: '', component: HomeComponent, children:[
    //{path: 'list', component: ListConfigureBankComponent},
    {path: 'create', component: CreateBankComponent}    
  ]}
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ConfigureBankRoutingModule { }
