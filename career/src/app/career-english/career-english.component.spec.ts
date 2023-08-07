import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CareerEnglishComponent } from './career-english.component';

describe('CareerEnglishComponent', () => {
  let component: CareerEnglishComponent;
  let fixture: ComponentFixture<CareerEnglishComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CareerEnglishComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(CareerEnglishComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
