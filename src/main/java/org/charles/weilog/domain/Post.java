package org.charles.weilog.domain;

import lombok.Data;
import lombok.NoArgsConstructor;
import lombok.experimental.Accessors;
import org.charles.weilog.constant.Constants;

import javax.persistence.*;
import java.util.ArrayList;
import java.util.Date;
import java.util.List;

/**
 * 文章。
 */
@Data
@Accessors(chain = true)
@NoArgsConstructor
@Entity
@Table(name = "posts")
public class Post {
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private Long id;
    private String title;
    @Basic(fetch = FetchType.LAZY)
    @Lob
    private String content;
    // 文章摘要
    private String excerpt;
    // 分类 Id
    private Long taxonomyId;
    // 文章类型（post/page等）
    @Enumerated(EnumType.ORDINAL)
    private Constants.PostType type;
    // 文章别名
    private String alias;
    // 点击数
    private Integer views;
    // 版权声明
    private String password;
    // 评论状态（open/closed）
    private boolean commentStatus;
    // 文章状态（publish/auto-draft/inherit等）
    @Enumerated(EnumType.ORDINAL)
    private Constants.PostStatus status;
    // 是否推荐
    private boolean recommend;

    @Column(insertable = false, updatable = false)
    private Integer userId;

    @OneToMany(cascade = {CascadeType.PERSIST})
    @JoinColumn(name = "postId", foreignKey = @ForeignKey(name = "none", value = ConstraintMode.NO_CONSTRAINT))
    private List<Attachment> attachments = new ArrayList<>();

    @ManyToOne
    @JoinColumn(name = "userId")
    private User user;

    @ManyToMany(cascade = {CascadeType.PERSIST})
    @JoinTable(name = "post_tags", joinColumns = {@JoinColumn(name = "post_id")}, inverseJoinColumns = {@JoinColumn(name = "tag_id")})
    private List<Tag> tags = new ArrayList<>();

    @OneToMany(cascade = {CascadeType.REMOVE})
    @JoinColumn(name = "postId", foreignKey = @ForeignKey(name = "none", value = ConstraintMode.NO_CONSTRAINT))
    private List<Comment> comments = new ArrayList<>();

    @Temporal(TemporalType.TIMESTAMP)
    private Date createdTime;
    @Temporal(TemporalType.TIMESTAMP)
    private Date modifiedTime;
}