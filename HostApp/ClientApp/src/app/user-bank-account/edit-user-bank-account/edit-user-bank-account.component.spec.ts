import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { EditUserBankAccountComponent } from './edit-user-bank-account.component';

describe('EditUserBankAccountComponent', () => {
  let component: EditUserBankAccountComponent;
  let fixture: ComponentFixture<EditUserBankAccountComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ EditUserBankAccountComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(EditUserBankAccountComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
