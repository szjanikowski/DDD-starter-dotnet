﻿
# Offer Request

This view contains details information about Offer Request building block, including:
- dependencies
- modules
- related processes  

---



## Domain Perspective


### Dependencies

```mermaid
  flowchart TB
    subgraph 0["Pricing"]
      1(Offer Request)
      class 1 DomainPerspective
    end
    subgraph 2["Clients"]
      3([Client Id])
      class 3 DomainPerspective
    end
    0-->|depends on|2
    classDef DomainPerspective stroke:#009900
    classDef TechnologyPerspective stroke:#1F41EB
    classDef PeoplePerspective stroke:#FFF014
```

### Related process steps

Offer Request is not used directly in any process step.  

## Next steps


### Zoom-in


#### Domain perspective


##### Ddd value objects

[Client Id](../Clients/Client Id.md)  

### Zoom-out


#### Domain perspective


##### Domain modules

[Pricing](Pricing.md)  

---

[P3 Model](https://github.com/P3-model/P3-model) documentation generated from source code using [.net tooling](https://github.com/P3-model/P3-model-dotnet)