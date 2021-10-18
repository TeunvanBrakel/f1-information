import { ValueConverter } from '@angular/compiler/src/render3/view/template';
import { Component } from '@angular/core';
import { observable } from 'rxjs';
import { HttpClient, HttpHeaders } from '@angular/common/http';

var data = undefined;

var i = 0;

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
  public async GetDrivers() {
    var testdata = [];
    var test =await this.http.get('http://localhost:5000/weatherforecast').forEach(value => testdata.push(value) && console.log(value));
    console.log(testdata.length)
    for(i=0; i < testdata.length; i++){
        console.log(i);
    }
    console.log();
    return this.http.get('http://localhost:5000/weatherforecast').forEach(value => testdata.push(value));
  }
  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
  };
}

