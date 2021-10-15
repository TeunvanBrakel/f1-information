import { ValueConverter } from '@angular/compiler/src/render3/view/template';
import { Component } from '@angular/core';
import { observable } from 'rxjs';
import { HttpClient, HttpHeaders } from '@angular/common/http';

var data = undefined;

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'f1-information-frontend';
  
  constructor(private http: HttpClient){
    data = this.GetDrivers();
    // console.log( data);
  }
  public GetDrivers() {
    var test = this.http.get('http://localhost:5000/weatherforecast').subscribe(value => data = value)
    console.log(this.http.get('http://localhost:5000/weatherforecast').subscribe(value => value.toString()));
    return test;
  }
  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
  };
}

