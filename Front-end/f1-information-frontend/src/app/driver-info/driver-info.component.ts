import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute, ParamMap } from '@angular/router';
import { HttpClient, HttpHeaders } from '@angular/common/http';
@Component({
  selector: 'app-driver-info',
  templateUrl: './driver-info.component.html',
  styleUrls: ['./driver-info.component.scss']
})
export class DriverInfoComponent implements OnInit {
  private driver: any = new Object;
  name : string = "";
  age : number = 0;
  currentTeam: string = "";
  image: string = "";
  id: number = 0;
  constructor(
    private http: HttpClient,
    private route: ActivatedRoute,
    ){ }

  public async GetDriver(id: number) {
    await this.http.get<any>('https://localhost:44381/driver/'+id).forEach(value => this.driver = value.valueOf());
    this.name = this.driver.name;
    this.age = this.driver.age;
    this.currentTeam = this.driver.currentTeam;
    this.image = this.driver.image;
  }
  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
  };
  async ngOnInit(): Promise<void> {
    this.route.params.subscribe(params => {
      this.id = +params['id'];
    });
    await this.GetDriver(this.id);
    onchange;
  }

}