import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AdminHomeComponent } from './admin-home/admin-home.component';
import { HomeComponent } from './home/home.component';

const AdminRoutes: Routes = [
  {
    path: '', component: AdminHomeComponent,
    children: [
      { path: '', component: HomeComponent }
      // { path: 'movies', loadChildren: '../movies-admin/movies-admin.module#MoviesAdminModule' },
      // { path: 'genres', loadChildren: '../genre-admin/genre-admin.module#GenreAdminModule' },
      // { path: 'orgs', loadChildren: '../organizations/organizations-admin.module#OrganizationsAdminModule' },
      // { path: 'show/:id', loadChildren: '../show-admin/show-admin.module#ShowAdminModule' },
      // { path: 'travels', loadChildren: '../travels/travels.module#TravelsModule' }
      // { path: 'region/:id', loadChildren: '../region/region.module#RegionModule'}

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
