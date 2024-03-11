import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ResponsibleTicketsComponent } from './responsible-tickets.component';

describe('ResponsibleTicketsComponent', () => {
  let component: ResponsibleTicketsComponent;
  let fixture: ComponentFixture<ResponsibleTicketsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ResponsibleTicketsComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ResponsibleTicketsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
