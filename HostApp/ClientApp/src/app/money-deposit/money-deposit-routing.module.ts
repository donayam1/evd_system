import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { ListMoneyDepositComponent } from './list-money-deposit/list-money-deposit.component';
import { CreateMoneyDepositComponent } from './create-money-deposit/create-money-deposit.component';

const routes: Routes = [
  {path: '', component: HomeComponent , children:[
    {path: 'list' , component: ListMoneyDepositComponent },
    {path: 'add' , component: CreateMoneyDepositComponent }
  ]}
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class MoneyDepositRoutingModule { }
