import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UPHFabricComponent } from './uphfabric.component';

describe('UPHFabricComponent', () => {
  let component: UPHFabricComponent;
  let fixture: ComponentFixture<UPHFabricComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ UPHFabricComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(UPHFabricComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
