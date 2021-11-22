import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { DriverInfoComponent} from '../app/driver-info/driver-info.component';
import { HomeComponent } from '../app/home/home.component';

const routes: Routes = [
  {path: "driverInfo/:id", component: DriverInfoComponent},
  {path: "home", component: HomeComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
