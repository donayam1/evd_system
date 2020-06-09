import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AdminHomeComponent } from './admin-home/admin-home.component';
import { HomeComponent } from './home/home.component';

const AdminRoutes: Routes = [
  {
    path: '', component: AdminHomeComponent,
    children: [
      { path: '', component: HomeComponent },
      { path: 'groups', loadChildren: '../group-type/group-type.module#GroupTypeModule' },
      { path: 'operators', loadChildren: '../operator/operator.module#OperatorModule' },
      { path: 'vouchers', loadChildren: '../vouchers/vouchers.module#VouchersModule' },
      { path: 'retailarPlans', loadChildren: '../retailer-plan/retailer-plan.module#RetailerPlanModule' },
      { path: 'po', loadChildren: '../purchase-order/purchase-order.module#PurchaseOrderModule' },
      { path: 'user', loadChildren: '../user/user.module#UserModule' },
      {path: 'vouchersBatch' , loadChildren: '../voucher-batch/voucher-batch.module#VoucherBatchModule' },
      {path: 'voucherStatistics', loadChildren: "../voucher-statistics/voucher-statistics.module#VoucherStatisticsModule"},
      { path: 'banks', loadChildren: '../configure-bank/configure-bank.module#ConfigureBankModule' }
       
      
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
