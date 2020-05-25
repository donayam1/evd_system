import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ListGroupTypeComponent } from './list-group-type.component';

describe('ListGroupTypeComponent', () => {
  let component: ListGroupTypeComponent;
  let fixture: ComponentFixture<ListGroupTypeComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ListGroupTypeComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ListGroupTypeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
