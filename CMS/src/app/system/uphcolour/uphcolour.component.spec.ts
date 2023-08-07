import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UPHColourComponent } from './uphcolour.component';

describe('UPHColourComponent', () => {
  let component: UPHColourComponent;
  let fixture: ComponentFixture<UPHColourComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ UPHColourComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(UPHColourComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
