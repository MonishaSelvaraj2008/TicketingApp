import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CreateCustomerSupportComponent } from './create-customer-support.component';

describe('CreateCustomerSupportComponent', () => {
  let component: CreateCustomerSupportComponent;
  let fixture: ComponentFixture<CreateCustomerSupportComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CreateCustomerSupportComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(CreateCustomerSupportComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
