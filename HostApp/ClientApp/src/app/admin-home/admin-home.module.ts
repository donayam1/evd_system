import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AdminHomeComponent } from './admin-home/admin-home.component';
import { AdminRoutingModule } from './admin-routing.module';
// import { TreeModule } from 'angular-tree-component';
import { HomeComponent } from './home/home.component';

@NgModule({
  imports: [
    CommonModule,
    AdminRoutingModule
    // ,
    // TreeModule.forRoot()
  ],
  declarations: [AdminHomeComponent, HomeComponent]
})
export class AdminHomeModule { }
