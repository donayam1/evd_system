import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AdminHomeComponent } from './admin-home/admin-home.component';
import { HomeComponent } from './home/home.component';

const AdminRoutes: Routes = [
  {
    path: '', component: AdminHomeComponent,
    children: [
      { path: '', component: HomeComponent },
      { path: 'groups', loadChildren:'../group-type/group-type.module#GroupTypeModule' },
      { path: 'operators', loadChildren:'../operator/operator.module#OperatorModule' }
      

    ]
  },
];

@NgModule({
  imports: [
    RouterModule.forChild(AdminRoutes),
  ],
  exports: [RouterModule]
})
export class AdminRoutingModule { }
