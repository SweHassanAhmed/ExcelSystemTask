import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { User } from 'src/app/models/user';
import { CrudServiceService } from 'src/app/services/crud-service.service';
import { NgForm } from '@angular/forms';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-user',
  templateUrl: './user.component.html',
  styleUrls: ['./user.component.css']
})
export class UserComponent implements OnInit {

  constructor(private route:ActivatedRoute, private crudOperation:CrudServiceService, private http:Router) { }

  editFlag:boolean = false;
  modelData:User = new User();

  ngOnInit() {
    this.route.params.subscribe(
      (data)=>{
        if(data.id)
        {
          this.editFlag = true;
          this.setUserData(data.id);
        }
      }
    );
  }

  Save(form:NgForm){
    if(form.valid){
      if(this.editFlag){
        this.crudOperation.update('users',this.modelData.UserID,this.modelData).subscribe(
          (data)=>{
            console.log(data);
            this.http.navigate(['users']);
          },
          (err)=>{
            console.log(err);
          }
        );
      }else{
        this.crudOperation.add('users',this.modelData).subscribe(
          (data)=>{
            this.http.navigate(['users']);
          },
          (err)=>{
            console.log("Error");
            console.log(err);
          }
        );
      }
    }
  }

  setUserData(id:number){
    this.crudOperation.getById('Users',id).subscribe(
      (data)=>{
        this.modelData = <User>data;
      }
    );
  }

}
