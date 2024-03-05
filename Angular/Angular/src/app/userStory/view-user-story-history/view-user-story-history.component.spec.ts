import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ViewUserStoryHistoryComponent } from './view-user-story-history.component';

describe('ViewUserStoryHistoryComponent', () => {
  let component: ViewUserStoryHistoryComponent;
  let fixture: ComponentFixture<ViewUserStoryHistoryComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ViewUserStoryHistoryComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ViewUserStoryHistoryComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
