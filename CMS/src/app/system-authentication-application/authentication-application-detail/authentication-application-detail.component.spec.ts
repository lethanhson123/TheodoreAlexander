import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AuthenticationApplicationDetailComponent } from './authentication-application-detail.component';

describe('AuthenticationApplicationDetailComponent', () => {
  let component: AuthenticationApplicationDetailComponent;
  let fixture: ComponentFixture<AuthenticationApplicationDetailComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AuthenticationApplicationDetailComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AuthenticationApplicationDetailComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
