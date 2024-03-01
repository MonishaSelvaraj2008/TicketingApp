import { CreateCustomerSupportComponent } from './customerSupport/create-customer-support/create-customer-support.component';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './login/login/login.component';
import { HomeComponent } from './home/home.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { CreateBugComponent } from './bug/create-bug/create-bug.component';
import { CreateUserStoryComponent } from './userStory/create-user-story/create-user-story.component';
import { UpdateUserStoryComponent } from './userStory/update-user-story/update-user-story.component';
import { RolebasedGuard } from './guards/rolebased.guard';
import { UserStoryListComponent } from './user-story-list/user-story-list.component';
import { UserStoryDescriptionComponent } from './userStory/user-story-description/user-story-description.component';
import { ForgotPasswordComponent } from './forgot-password/forgot-password.component';

const routes: Routes = [
  {
    path: '', component: HomeComponent
  },
  {
    path: 'dashboard', component: DashboardComponent, canActivate:[RolebasedGuard], data:{role:'user'}
  },
  {
    path: 'login', component: LoginComponent
  },
  {
    path: 'ForgotPassword', component: ForgotPasswordComponent
  },

  {path: 'createUserStory', component:CreateUserStoryComponent, canActivate:[RolebasedGuard], data:{role:'user' }},
  {path: 'updateUserStory/:id', component:UpdateUserStoryComponent, canActivate:[RolebasedGuard], data:{role:'user' }},
  {path: 'createBug', component:CreateBugComponent, canActivate:[RolebasedGuard], data:{role:'user'} },
  { path: 'userStoryList', component: UserStoryListComponent },
  { path: 'description/:id', component: UserStoryDescriptionComponent },
  {
    path: 'createCustomerSupport', component:CreateCustomerSupportComponent, canActivate:[RolebasedGuard], data:{role:'user' }},
  {
    path: 'app',
    loadChildren: () => import('./application/application.module').then(m => m.ApplicationModule)
  }];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule
{

}


