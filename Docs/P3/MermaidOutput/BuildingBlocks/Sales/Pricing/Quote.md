﻿
# [*Domain building block*] Quote

This view contains details information about Quote building block, including:
- dependencies
- modules
- related processes  

---



## Domain Perspective


### Dependencies

```mermaid
  flowchart TB
    subgraph 0["Pricing"]
      1(Quote)
      class 1 DomainPerspective
    end
    subgraph 2["Commons"]
      3([Money])
      class 3 DomainPerspective
    end
    subgraph 4["Pricing"]
      5([QuoteModifier])
      class 5 DomainPerspective
    end
    subgraph 6["Products"]
      7([ProductAmount])
      class 7 DomainPerspective
    end
    0-->|depends on|2
    0-->|depends on|4
    0-->|depends on|6
    classDef DomainPerspective stroke:#009900
    classDef TechnologyPerspective stroke:#1F41EB
    classDef PeoplePerspective stroke:#FFF014
```

### Related process steps

```mermaid
  flowchart TB
    0(Quote)
    class 0 DomainPerspective
    1([PriceCart])
    class 1 DomainPerspective
    0-->|is used in|1
    2([ConfirmOffer])
    class 2 DomainPerspective
    0-->|is used in|2
    3([GetOffer])
    class 3 DomainPerspective
    0-->|is used in|3
    4([CreateOrder])
    class 4 DomainPerspective
    0-->|is used in|4
    classDef DomainPerspective stroke:#009900
    classDef TechnologyPerspective stroke:#1F41EB
    classDef PeoplePerspective stroke:#FFF014
```

## Next steps


### Zoom-out

- [[*Domain module*] Pricing](../../../Modules/Sales/Pricing/Pricing.md)

### Change perspective

- [[*Domain building block*] QuoteModifier](QuoteModifier.md)
- [[*Domain building block*] ProductAmount](../Products/ProductAmount.md)
- [[*Domain building block*] Money](../Commons/Money.md)

---

[P3 Model](https://github.com/P3-model/P3-model) documentation generated from source code using [.net tooling](https://github.com/P3-model/P3-model-dotnet)