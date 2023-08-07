import { ComponentFixture, TestBed } from '@angular/core/testing';

import { HREmployeeUploadComponent } from './hr-employee-upload.component';

describe('HREmployeeUploadComponent', () => {
  let component: HREmployeeUploadComponent;
  let fixture: ComponentFixture<HREmployeeUploadComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ HREmployeeUploadComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(HREmployeeUploadComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
