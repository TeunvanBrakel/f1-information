import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { BannedComponent } from './banned/banned.component';

import { LoginComponent } from './login/login.component';
import { UsersComponent } from './users/users.component';

const routes: Routes = [
  {path: 'login', component: LoginComponent},
  {path: 'users', component: UsersComponent},
  {path: 'banned', component: BannedComponent},
  {path: '', redirectTo: 'login', pathMatch: 'full'},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
