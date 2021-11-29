import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { DriverInfoComponent} from '../app/driver-info/driver-info.component';
import { HomeComponent } from '../app/home/home.component';
import { AllDriversComponent } from './all-drivers/all-drivers.component';

const routes: Routes = [
  {path: "driverInfo/:id", component: DriverInfoComponent},
  {path: "home", component: HomeComponent},
  {path: "allDrivers", component: AllDriversComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule {
  
 }
