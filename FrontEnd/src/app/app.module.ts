import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';

import { AppComponent } from './app.component';
import { from } from 'rxjs';
import { AppRoutingModule } from './app-routing.module';
import { UserListComponent } from './content/user/user-list/user-list.component';
import { HttpClientModule, HTTP_INTERCEPTORS } from "@angular/common/http";
import { UserComponent } from './content/user/user/user.component';
import { LoginComponent } from './content/login/login.component';
import { AuthInterceptor } from './content/interceptor/auth.interceptor';

@NgModule({
  declarations: [
    AppComponent,
    UserListComponent,
    UserComponent,
    LoginComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    HttpClientModule
  ],
  providers: [{
    provide: HTTP_INTERCEPTORS,
    useClass: AuthInterceptor,
    multi: true
  }],
  bootstrap: [AppComponent]
})
export class AppModule { }
