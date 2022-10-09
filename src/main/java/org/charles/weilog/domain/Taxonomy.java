package org.charles.weilog.domain;

import lombok.Data;
import lombok.NoArgsConstructor;
import lombok.experimental.Accessors;

import javax.persistence.*;
import java.util.Date;

@Data
@Accessors(chain = true)
@NoArgsConstructor
@Entity
@Table(name = "taxonomy")
public class Taxonomy {
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private Long id;
    private String name;
    private String description;
    // 别名
    private String alias;
    // 类型
    private Integer type;
    // 父级 Id
    private Long parentId;
    // 统计数量
    private Integer count;
    private String slug;
    private Integer sortOrder;
    private Boolean deleted;
    private Boolean enabled;
    @Temporal(TemporalType.TIMESTAMP)
    private Date createdTime;
    @Temporal(TemporalType.TIMESTAMP)
    private Date modifiedTime;
}