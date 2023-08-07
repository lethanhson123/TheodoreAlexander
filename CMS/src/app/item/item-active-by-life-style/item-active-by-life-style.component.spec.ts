import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ItemActiveByLifeStyleComponent } from './item-active-by-life-style.component';

describe('ItemActiveByLifeStyleComponent', () => {
  let component: ItemActiveByLifeStyleComponent;
  let fixture: ComponentFixture<ItemActiveByLifeStyleComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ItemActiveByLifeStyleComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ItemActiveByLifeStyleComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
