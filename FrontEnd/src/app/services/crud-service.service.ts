import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse, HttpHeaders, HttpHeaderResponse} from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs';


@Injectable({
  providedIn: 'root'
})
export class CrudServiceService {

  constructor(private Http:HttpClient) { }

  getList(controllerName:string){
    return this.Http.get(environment.url + controllerName);
  }
  
  add(controllerName:string, data:any){
    return this.Http.post(environment.url + controllerName, data);
  }

  update(controllerName:string, id:number, data:any){
    return this.Http.put(environment.url + controllerName + '/' + id, data);
  }

  delete(controllerName:string, id:number){
    return this.Http.delete(environment.url + controllerName + '/' + id);
  }

  getById(controllerName:string, id:number){
    return this.Http.get(environment.url + controllerName + '/' + id);
  }
  
}
