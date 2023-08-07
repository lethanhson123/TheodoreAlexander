import { ComponentFixture, TestBed } from '@angular/core/testing';

import { HREMployeeDetailComponent } from './hr-employee-detail.component';

describe('HREMployeeDetailComponent', () => {
  let component: HREMployeeDetailComponent;
  let fixture: ComponentFixture<HREMployeeDetailComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ HREMployeeDetailComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(HREMployeeDetailComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
