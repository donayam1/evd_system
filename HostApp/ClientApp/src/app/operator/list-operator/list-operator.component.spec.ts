import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ListOperatorComponent } from './list-operator.component';

describe('ListOperatorComponent', () => {
  let component: ListOperatorComponent;
  let fixture: ComponentFixture<ListOperatorComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ListOperatorComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ListOperatorComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
