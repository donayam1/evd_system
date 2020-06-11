import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CreateMoneyDepositComponent } from './create-money-deposit.component';

describe('CreateMoneyDepositComponent', () => {
  let component: CreateMoneyDepositComponent;
  let fixture: ComponentFixture<CreateMoneyDepositComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CreateMoneyDepositComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CreateMoneyDepositComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
