import { CreateCustomerSupportComponent } from './customerSupport/create-customer-support/create-customer-support.component';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './login/login/login.component';
import { HomeComponent } from './home/home.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { CreateBugComponent } from './bug/create-bug/create-bug.component';
import { CreateUserStoryComponent } from './userStory/create-user-story/create-user-story.component';
import { UpdateUserStoryComponent } from './userStory/update-user-story/update-user-story.component';

const routes: Routes = [
  {
    path: '', component: HomeComponent
  },
  {
    path: 'dashboard', component: DashboardComponent
  },
  {
    path: 'login', component: LoginComponent
  },

  {path: 'createUserStory', component:CreateUserStoryComponent },
  {path: 'updateUserStory', component:UpdateUserStoryComponent },
  {path: 'createBug', component:CreateBugComponent },
  {
    path: 'createCustomerSupport', component:CreateCustomerSupportComponent },
  {
    path: 'app',
    loadChildren: () => import('./application/application.module').then(m => m.ApplicationModule)
  }];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
