import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SystemAuthenticationMenuComponent } from './system-authentication-menu.component';

describe('SystemAuthenticationMenuComponent', () => {
  let component: SystemAuthenticationMenuComponent;
  let fixture: ComponentFixture<SystemAuthenticationMenuComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SystemAuthenticationMenuComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(SystemAuthenticationMenuComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
