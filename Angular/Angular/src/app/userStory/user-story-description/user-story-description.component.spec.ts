import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UserStoryDescriptionComponent } from './user-story-description.component';

describe('UserStoryDescriptionComponent', () => {
  let component: UserStoryDescriptionComponent;
  let fixture: ComponentFixture<UserStoryDescriptionComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ UserStoryDescriptionComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(UserStoryDescriptionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
