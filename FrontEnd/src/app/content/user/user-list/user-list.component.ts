import { Component, OnInit } from '@angular/core';
import { User } from 'src/app/models/user';
import { CrudServiceService } from 'src/app/services/crud-service.service';
import { Route } from '@angular/compiler/src/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-user-list',
  templateUrl: './user-list.component.html',
  styleUrls: ['./user-list.component.css']
})
export class UserListComponent implements OnInit {

  public users:any;

  constructor(private listService:CrudServiceService,private router:Router) { }

  ngOnInit() {
    this.init();
  }

  DeleteUser(userID:number){
    this.listService.delete('users', userID).subscribe(
      (data)=>{
        this.init();
      }
    );
  }

  logout(){
    localStorage.removeItem('token');
    this.router.navigate(['login']);
  }

  init(){
    console.log("Go Init...");
    this.listService.getList('Users/GetUsers').subscribe(
      (data)=>{
        this.users = data;
        console.log(this.users);
      },
      (err)=>{
        console.log(err);
      }
    );
  }

}
