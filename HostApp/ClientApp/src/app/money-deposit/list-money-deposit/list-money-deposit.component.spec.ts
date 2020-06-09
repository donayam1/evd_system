import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ListMoneyDepositComponent } from './list-money-deposit.component';

describe('ListMoneyDepositComponent', () => {
  let component: ListMoneyDepositComponent;
  let fixture: ComponentFixture<ListMoneyDepositComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ListMoneyDepositComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ListMoneyDepositComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
