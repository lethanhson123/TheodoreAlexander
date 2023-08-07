import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SystemAuthenticationApplicationComponent } from './system-authentication-application.component';

describe('SystemAuthenticationApplicationComponent', () => {
  let component: SystemAuthenticationApplicationComponent;
  let fixture: ComponentFixture<SystemAuthenticationApplicationComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SystemAuthenticationApplicationComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(SystemAuthenticationApplicationComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
