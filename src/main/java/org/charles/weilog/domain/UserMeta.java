package org.charles.weilog.domain;

import lombok.Data;
import lombok.NoArgsConstructor;
import lombok.experimental.Accessors;

import javax.persistence.*;

/**
 * 用户元数据。
 */
@Data
@Accessors(chain = true)
@NoArgsConstructor
@Entity
@Table(name = "user_meta")
public class UserMeta {
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private Long id;

    private Long userId;

    private String metaKey;

    private String metaValue;
}