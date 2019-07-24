import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';


import { AppComponent } from './app.component';
import { CreateComponent } from './create/create.component';
import { EditComponent } from './edit/edit.component';
//import { DeleteComponent } from './delete/delete.component';
import { HomeComponent } from './home/home.component';
import { ViewComponent } from './view/view.component';
import { RouterModule, Routes } from '@angular/router';

import { HttpModule } from '@angular/http';
import { LoginComponent } from './login/login.component';
const appRoutes: Routes = [
  
  {
    path: 'homes',
    component: HomeComponent,
    data: { title: 'HomeList' }
  },
  {
    path: 'view/:id',
    component: ViewComponent,
    data: { titlea: 'TaskDetails' }
  },
  {
    path: 'create',
    component: CreateComponent,
    data: { titlea: 'CreateTask' }
  },
  {
    path: 'login',
    component: LoginComponent,
    data: { titlea: 'Login' }
  },
  {
    path: 'edit/:id',
    component: EditComponent,
    data: { titlea: 'EditTask' }
  },
  { path: '',
    redirectTo: '/login',
    pathMatch: 'full'
  }
];
@NgModule({
  declarations: [
    AppComponent,
    
    CreateComponent,
    EditComponent,
    //DeleteComponent,
    HomeComponent,
    ViewComponent,
    LoginComponent
    
  ],
  imports: [
    BrowserModule,
    HttpModule,
    FormsModule,
    HttpClientModule,
    RouterModule.forRoot(
      appRoutes,
      { enableTracing: true } // <-- debugging purposes only
    )
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }

