//import { Component, OnInit } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { Component, OnInit, ViewEncapsulation } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-view',
  templateUrl: './view.component.html',
  styleUrls: ['./view.component.css'],
  encapsulation: ViewEncapsulation.None
})

export class ViewComponent implements OnInit {

  public home={};
  constructor(private router: Router, private route: ActivatedRoute, private http: HttpClient) { }

  ngOnInit() {
    this.getUserDetail(this.route.snapshot.params['id']);
  }

  getUserDetail(id) {
    this.http.get('http://localhost:7254/api/item/GetById/'+id).subscribe(data => {
      this.home = data;
      console.log(data);
    });

    
  }  
  deleteUser(id) {
    this.http.delete('http://localhost:7254/api/item/Delete/'+id)
      .subscribe(res => {
          //let id = res['id'];
          console.log(res);  
          this.router.navigate(['/homes/']);
        }, (err) => {
          console.log(err);
        }
      );
  }
}
