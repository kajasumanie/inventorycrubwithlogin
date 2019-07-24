import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ViewEncapsulation } from '@angular/core';
import { UrlResolver } from '@angular/compiler';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css'],
  encapsulation: ViewEncapsulation.None
})
export class LoginComponent implements OnInit {
 // datas= {};
  datas: any = {
    UserName: '',
    Password: ''
  };
  // username: string = "";
  // password:string ="";
  constructor(private http: HttpClient, private router: Router) { }

  ngOnInit() {
  }
  validateuser() {
    this.http.post('http://localhost:7254/api/user/token',this.datas)
      .subscribe(res => {
        console.log(res);
        this.router.navigate(['/homes']);
         
         
        }, (err) => {
          this.router.navigate(['/login']);
        }
        
      );
      }
    }
