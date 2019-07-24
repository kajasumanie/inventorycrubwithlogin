import { Component, OnInit, ViewEncapsulation } from '@angular/core';
import {Http, Headers}  from '@angular/http';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';


@Component({
  selector: 'app-create',
  templateUrl: './create.component.html',
  styleUrls: ['./create.component.css'],
  encapsulation: ViewEncapsulation.None
})
export class CreateComponent implements OnInit {
  //today: number = Date.now();
  home= {};
  constructor(private http: HttpClient, private router: Router) { }
  
  ngOnInit() {
    
  }

  
  saveUser() {
    this.http.post('http://localhost:7254/api/item/Create', this.home)
      .subscribe(res => {
        console.log(res);
        this.router.navigate(['/homes']);
         
         
        }, (err) => {
          this.router.navigate(['/homes']);
        }
        
      );
     
  }
}
