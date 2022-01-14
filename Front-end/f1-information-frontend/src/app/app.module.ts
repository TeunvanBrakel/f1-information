import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { HomeComponent } from './home/home.component';
import { DriverInfoComponent } from './driver-info/driver-info.component';
import { AllDriversComponent } from './all-drivers/all-drivers.component';
import { LoginComponent } from '../app/login/login.component';
import { RegisterComponent } from '../app/register/register.component';
import { ProfileComponent } from '../app/profile/profile.component';
import { BoardAdminComponent } from '../app/board-admin/board-admin.component';
import { BoardModeratorComponent } from '../app/board-moderator/board-moderator.component';
import { BoardUserComponent } from '../app/board-user/board-user.component';

import { authInterceptorProviders} from '../app/_helpers/auth.interceptor';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    DriverInfoComponent,
    AllDriversComponent,
    LoginComponent,
    RegisterComponent,
    ProfileComponent,
    BoardAdminComponent,
    BoardModeratorComponent,
    BoardUserComponent,
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    FormsModule,
    AppRoutingModule,
    HttpClientModule,
    RouterModule.forRoot([
      {path: 'driver-info', component: DriverInfoComponent}
    ])
  ],
  providers: [authInterceptorProviders],
  bootstrap: [AppComponent]
})
export class AppModule { }
