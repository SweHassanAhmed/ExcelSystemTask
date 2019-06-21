import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { User } from 'src/app/models/user';
import { CrudServiceService } from 'src/app/services/crud-service.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  user:User = new User();

  constructor(private crudOperation:CrudServiceService, private router:Router) { }

  ngOnInit() {
  }

  CheckUserData(ngForm:NgForm){
    this.crudOperation.add('Security',this.user).subscribe(
      (data:any)=>{
        localStorage.setItem('token',data.token);
        console.log(localStorage.getItem('token'));
        this.router.navigate(['/users']);
      },
      (err)=>{
        console.log(err);
      }
    );
  }


}
