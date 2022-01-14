import { HttpClient, HttpClientModule } from '@angular/common/http';
import { TestBed } from '@angular/core/testing';

import { AuthService } from './auth.service';

describe('AuthService', () => {
  let service: AuthService;

  beforeEach(async () => {
    TestBed.configureTestingModule({
      imports: [HttpClientModule],
    })
  })

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(AuthService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });

  it('accounts should be created', () => {
    var username: string = "piet";
    var ww: string = "test";
    var email: string ="test@gmail.com";
    expect(service.register(username, email, ww)).toBeTruthy();
  })

  it('token is send back', () =>{
    var username: string = "piet";
    var ww: string = "test";
    expect(service.login(username, ww)).toBeTruthy();
  })
});
