import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AppComponent } from './app.component';
import { UserListComponent } from './content/user/user-list/user-list.component';
import { UserComponent } from './content/user/user/user.component';
import { LoginComponent } from './content/login/login.component';
import { AuthGuard } from './auth/auth.guard';

const routes: Routes = [
	{
		path : '',
		component : LoginComponent
	},
	{
		path : 'users',
		component : UserListComponent,
		canActivate : [AuthGuard]
	},
	{
		path : 'users/add',
		component : UserComponent,
		canActivate : [AuthGuard]
	},
	{
		path : 'users/edit/:id',
		component : UserComponent,
		canActivate : [AuthGuard]
	},
	{
		path : 'login',
		component : LoginComponent,
	}
];

@NgModule({
	imports: [
		RouterModule.forRoot(routes)
	],
	exports: [RouterModule]
})
export class AppRoutingModule {}
