import { Component, OnInit, ChangeDetectionStrategy } from '@angular/core';
import { TargetLocator } from 'selenium-webdriver';
import { HttpClient } from '@angular/common/http';

import { UrlResolver } from '@angular/compiler';
import { Router } from '@angular/router';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  homes: any;
  searchkey: string = "";

  constructor(private http: HttpClient) { }

  ngOnInit() {
    //console.log();
    this.http.get('http://localhost:7254/api/item/GetAll').subscribe(data => {
      this.homes = data;
      console.log(data);
    });
  }

  search(){
      this.getByDescription(this.searchkey)
  }

  getByDescription(description) {
    this.http.get('http://localhost:7254/api/item/GetByDescription/'+description).subscribe(data => {
      this.homes = []
      this.homes.push(data);
      console.log(data);
    });
  }  

}