import { Component, OnInit ,ViewEncapsulation} from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ActivatedRoute, Router } from '@angular/router';
import { ViewComponent} from '../view/view.component';

@Component({
  selector: 'app-edit',
  templateUrl: './edit.component.html',
  styleUrls: ['./edit.component.css'],
  encapsulation: ViewEncapsulation.None
})
export class EditComponent implements OnInit {

  sub: any;
  id: number;
  any: any;
  home = {};
  constructor(private http: HttpClient, private router: Router, private route: ActivatedRoute) { }

  ngOnInit() {
    //this.getUser(this.route.snapshot.params['id']);
    this.sub = this.route.params.subscribe(params => {
      this.id = params['id'];
      console.log(this.id);
      this.getUser(this.id);
    });
  }


  getUser(id) {
    this.http.get('http://localhost:7254/api/item/GetById/'+id).subscribe(data => {
      this.home = data;
      console.log(data);
    });
  }  

  getByName(name) {
    this.http.get('http://localhost:7254/api/item/GetByName/'+name).subscribe(data => {
      this.home = data;
    });
  }  

  getByDescription(description) {
    this.http.get('http://localhost:7254/api/item/GetByDescription/'+description).subscribe(data => {
      this.home = data;
      console.log(data);
    });
  }  
  updateUser(id, data) {
    //console.log(data);
    this.http.put('http://localhost:7254/api/item/Update/'+id, data)
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
