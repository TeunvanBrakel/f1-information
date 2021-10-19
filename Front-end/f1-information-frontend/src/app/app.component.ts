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
    console.log(data);
    // console.log( data);
  }
  public async GetDrivers() {
    var testdata: any[] = new Array;
    var test =await this.http.get<any>('https://localhost:44381/driver').forEach(value => testdata = value.valueOf());
    console.log(testdata.length)
    testdata.forEach(i => console.log(i));
    testdata.forEach(i => console.log(i.name));
    return await this.http.get<any>('https://localhost:44381/driver').forEach(value => testdata = value.valueOf());
  }
  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
  };
}

