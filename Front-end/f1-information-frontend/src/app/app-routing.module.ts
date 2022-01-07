import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { DriverInfoComponent} from '../app/driver-info/driver-info.component';
import { HomeComponent } from '../app/home/home.component';
import { AllDriversComponent } from './all-drivers/all-drivers.component';
import { RegisterComponent } from './register/register.component';
import { LoginComponent } from './login/login.component';
import { ProfileComponent } from './profile/profile.component';
import { BoardAdminComponent } from './board-admin/board-admin.component';
import { BoardModeratorComponent } from './board-moderator/board-moderator.component';
import { BoardUserComponent } from './board-user/board-user.component';

const routes: Routes = [
  {path: "driverInfo/:id", component: DriverInfoComponent},
  {path: "home", component: HomeComponent},
  {path: "allDrivers", component: AllDriversComponent},
  {path: 'login', component: LoginComponent},
  {path: 'register', component: RegisterComponent},
  {path: 'profile', component: ProfileComponent},
  {path: 'user', component: BoardUserComponent},
  {path: 'mod', component: BoardModeratorComponent},
  {path: 'admin', component: BoardAdminComponent},
  {path: '', redirectTo: 'home', pathMatch: 'full'},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule {
  
 }

