import { HttpClientModule } from '@angular/common/http';
import { ComponentFixture, TestBed } from '@angular/core/testing';
import { Router } from '@angular/router';
import { RouterTestingModule } from '@angular/router/testing';
import { TokenStorageService } from '../_services/token-storage.service';

import { BannedComponent } from './banned.component';


describe('BannedComponent', () => {
  let component: BannedComponent;
  let fixture: ComponentFixture<BannedComponent>;
  
  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ BannedComponent ],
      imports: [HttpClientModule],
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(BannedComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  // it('should create', () => {
  //   expect(component).toBeTruthy();
  // });
});
