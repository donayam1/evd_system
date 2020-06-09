import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { ListConfigureBankComponent } from './list-configure-bank/list-configure-bank.component';

const routes: Routes = [
  {path: '' , component: HomeComponent , children: [
    {path: 'list', component: ListConfigureBankComponent}
  ]}
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ConfigureBankRoutingModule { }
