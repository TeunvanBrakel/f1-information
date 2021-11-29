import { Component, OnInit } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Router, ActivatedRoute, ParamMap } from '@angular/router';

@Component({
  selector: 'app-all-drivers',
  templateUrl: './all-drivers.component.html',
  styleUrls: ['./all-drivers.component.scss']
})
export class AllDriversComponent implements OnInit {
  drivers: [];
  constructor(
    private http: HttpClient,
    private router: Router,
    ) {}

  ngOnInit(): void {
    this.GetAllDriver();
  }
  public GoToDriver(id: number){
    this.router.navigateByUrl("driverInfo/"+id);
  }
  
  private async GetAllDriver() {
    await this.http.get<any>('https://localhost:44381/driver').forEach(value => this.drivers = value.valueOf());
    console.log(this.drivers);
  }
  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
  };
}
