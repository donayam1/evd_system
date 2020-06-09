import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { ListMoneyDepositComponent } from './list-money-deposit/list-money-deposit.component';

const routes: Routes = [
  {path: '', component: HomeComponent , children:[
    {path: 'list' , component: ListMoneyDepositComponent }
  ]}
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class MoneyDepositRoutingModule { }
